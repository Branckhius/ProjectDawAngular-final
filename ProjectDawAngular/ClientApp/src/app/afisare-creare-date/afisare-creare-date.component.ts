import { Component } from '@angular/core';
import { ApiService } from 'src/app/core/services/api.service';

@Component({
  selector: 'app-afisare-creare-date',
  templateUrl: './afisare-creare-date.component.html',
  styleUrls: ['./afisare-creare-date.component.css']
})
export class AfisareCreareDateComponent {
  selectedType!: string;
  data: any[] = [];
  newData: any = {};

  constructor(private apiService: ApiService) {
    this.newData = {};
  }

  onSelectType(type: string): void {
    this.selectedType = type;

    // Inițializează obiectul newData cu proprietățile specifice tipului selectat
    if (type === 'Courses') {
      this.newData = { Id: 0, Title: '', Credits: 0, ProfessorId: 0 }; // Use numeric values for numeric properties
    } else if (type === 'Departments') {
      this.newData = { Id: 0, Name: '', Location: '' }; // Corrected properties for Departments
    } else if (type === 'ProfessorDetails') {
      this.newData = { Id: 0, OfficeLocation: '', ProfessorId: 0 };
    } else if (type === 'Professors') {
      this.newData = { Id: 0, Name: '', DepartmentId: 0 };
    } else if (type === 'StudentCourses') {
      this.newData = { StudentId: 0, CourseId: 0, Id: 0 };
    } else if (type === 'Students') {
      this.newData = { Id: 0, Name: '', Age: 0 };
    }

    this.apiService.getData(type).subscribe(data => this.data = data);
  }

  onAddData(): void {
    console.log('Adding data:', this.newData);

    this.apiService.addData(this.selectedType, this.newData).subscribe(
      data => {
        console.log('Response from API:', data);
        this.data = data;  // Asigură-te că această linie este apelată și că data este actualizată corect
      },
      error => {
        console.error('Error from API:', error);
      }
    );

    this.newData = {};
  }
  onDeleteData(type: string, id: number): void {
    console.log(`Deleting ${type} with ID: ${id}`);

    this.apiService.deleteData(type, id).subscribe(
      data => {
        console.log('Response from API:', data);
        this.data = data;  // Asigură-te că această linie este apelată și că data este actualizată corect
      },
      error => {
        console.error('Error from API:', error);
      }
    );
  }
  // Metoda pentru a obține numele proprietăților obiectului newData
  getProperties(obj: any): string[] {
    return obj ? Object.keys(obj) : [];
  }
}
