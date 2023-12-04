import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-add-task',
  templateUrl: './add-task.component.html',
  styleUrls: ['./add-task.component.css'],
})
export class AddTaskComponent {
  title: string = "";
  description: string = "";

  constructor(private http: HttpClient, private router: Router) { }

  save() {
    let bodyData = {
      "title": this.title,
      "description": this.description,
    };

    this.http.post("http://localhost:5031/api/ToDoList/AddList", bodyData).subscribe((resultData: any) => {
      console.log(resultData);
      alert("Task Noted Successfully");
      this.router.navigate(['/']);
    });
  }
}
