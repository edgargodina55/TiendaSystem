import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { StoreService } from 'src/app/services/store.service';

@Component({
  selector: 'app-stores',
  templateUrl: './stores.component.html',
  styleUrls: ['./stores.component.css']
})
export class StoresComponent implements OnInit {

  showForm = false;
  storeForm: FormGroup;
  stores: any[] = [];

  constructor(
    private fb: FormBuilder,
    private storeService: StoreService
  ) {
    this.storeForm = this.fb.group({
      name: ['', Validators.required],
      address: ['', Validators.required],
      status: [true]
    });
  }

  ngOnInit(): void {
    this.loadStores();
  }

  toggleForm(): void {
    this.showForm = !this.showForm;
    if (!this.showForm) {
      this.storeForm.reset({ status: true });
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
    if (this.storeForm.invalid) return;

    this.storeService.create(this.storeForm.value).subscribe({
      next: () => {
        this.loadStores();
        this.toggleForm();
      },
      error: (err) => console.error(err)
    });
  }

  editStore(store: any): void {
    this.showForm = true;
    // el backend te manda storeId, name, address, status
    this.storeForm.patchValue({
      name: store.name,
      address: store.address,
      status: store.status
    });
    // si quisieras actualizar, aquí guardarías el id para mandar PUT
  }

  deleteStore(storeId: number): void {
    if (!confirm('¿Seguro que deseas eliminar esta tienda?')) return;

    this.storeService.delete(storeId).subscribe({
      next: () => this.loadStores(),
      error: (err) => console.error(err)
    });
  }
}
