import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { ProductService } from 'src/app/services/product.service';
import { StoreService } from 'src/app/services/store.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  showForm = false;
  productForm: FormGroup;
  storeIdFromRoute: number | null = null; // para saber si estamos viendo productos de una tienda específica
  products: any[] = [];
  stores: any[] = [];   // para el select de tiendas
  quantities: { [productId: number]: number } = {}; // para el select de carrito

  constructor(
    private fb: FormBuilder,
    private authService : AuthService,
    private productService: ProductService,
    private storeService: StoreService,
    private route: ActivatedRoute
  ) {
    this.productForm = this.fb.group({
      name: ['', Validators.required],
      code: ['', Validators.required],
      description: [''],
      imageUrl: [''],
      stock: [0, [Validators.required, Validators.min(0)]],
      idStore: ['', Validators.required],
      status: [true]
    });
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const id = params.get('storeId');
      this.storeIdFromRoute = id ? Number(id) : null;
      this.loadProducts();
    });
    this.loadProducts();
    this.loadStores();
  }

  isAdmin(): boolean{
    return this.authService.isAdmin();
  }

  isCustomer():boolean{
    return this.authService.isCustomer();
  }

  toggleForm(): void {
    this.showForm = !this.showForm;
    if (!this.showForm) {
      this.productForm.reset({ status: true, stock: 0 });
    }
  }

  loadProducts(): void {
    if(this.authService.isAdmin()){
      this.productService.getAll().subscribe({
        next: (res) => {
          this.products = res.data || res || [];
          // inicializar cantidad por producto
          this.products.forEach(p => {
            this.quantities[p.productId] = 1;
          });
        },
        error: (err) => console.error('Error cargando productos', err)
      });
    }else if(this.authService.isCustomer()){
      if (!this.storeIdFromRoute) {
        console.warn('No se proporcionó storeId en la URL');
        return;
      }

      this.productService.getAllByStore(this.storeIdFromRoute).subscribe({
        next: (res) => {
          this.products = res.data || res || [];
          this.products.forEach(p => {
            this.quantities[p.productId] = 1;
          });
        },
        error: (err) => console.error('Error cargando productos (Customer)', err)
      });
    }
  }

   loadStores(): void {
    this.storeService.getAll().subscribe({
      next: (res) => {
        // si tu API responde { success, data: [...] }
        this.stores = res.data || res || [];
      },
      error: (err) => {
        console.error('Error cargando tiendas:', err);
      }
    });
  }

  onSubmit(): void {
    if (this.productForm.invalid) return;

    this.productService.create(this.productForm.value).subscribe({
      next: () => {
        this.loadProducts();
        this.toggleForm();
      },
      error: (err) => console.error(err)
    });
  }

  editProduct(prod: any): void {
    this.showForm = true;
    this.productForm.patchValue({
      name: prod.name,
      code: prod.code,
      description: prod.description,
      imageUrl: prod.imageUrl,
      stock: prod.stock,
      idStore: prod.idStore,
      status: prod.status
    });
    // si quieres actualizar, aquí guardarías el id en una variable aparte
  }

  deleteProduct(id: number): void {
    if (!confirm('¿Seguro que deseas eliminar este producto?')) return;

    this.productService.delete(id).subscribe({
      next: () => this.loadProducts(),
      error: (err) => console.error(err)
    });
  }

  changeQuantity(prodId: number, value: string): void {
    this.quantities[prodId] = Number(value);
  }

  addToCart(prod: any): void {
    const qty = this.quantities[prod.productId] || 1;
    console.log('Agregar al carrito 👉', { product: prod, quantity: qty });
    // aquí luego ya mandas al servicio de carrito
  }

}
