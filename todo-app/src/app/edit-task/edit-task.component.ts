import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-edit-task',
  templateUrl: './edit-task.component.html',
  styleUrls: ['./edit-task.component.css'],
})
export class EditTaskComponent {
  title: string = "";
  description: string = "";
  currentListID = "";

  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router) {
    this.currentListID = this.route.snapshot.paramMap.get('id') || "";

    // Fetch the task details using the currentListID and populate the form fields
    this.fetchTaskDetails();
  }

  fetchTaskDetails() {
    // Fetch task details using the currentListID and populate the form fields
    this.http.get(`http://localhost:5031/api/ToDoList/${this.currentListID}`).subscribe((resultData: any) => {
      this.title = resultData.title;
      this.description = resultData.description;
    });
  }

  save() {
    let bodyData = {
      "id": this.currentListID,
      "title": this.title,
      "description": this.description,
    };

    this.http.patch("http://localhost:5031/api/ToDoList/UpdateList/" + this.currentListID, bodyData).subscribe(
      (resultData: any) => {
        console.log(resultData);
        alert("Task Updated");

        // Redirect to the todo-list page after saving
        this.router.navigate(['/']);
      },
      (error) => {
        console.error(error);
        alert("Error updating task");
      }
    );
  }
}
