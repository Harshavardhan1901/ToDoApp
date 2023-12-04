import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css'],
})
export class TodoListComponent {
  ListArray: any[] = [];
  isResultLoaded = false;
  isUpdateFormActive = false;

  title: string = "";
  description: string = "";

  currentListID = "";

  constructor(private http: HttpClient, private router: Router) {
    this.getAllList();
  }

  ngOnInit(): void {}

  getAllList() {
    this.http.get("http://localhost:5031/api/ToDoList/GetList").subscribe((resultData: any) => {
      this.isResultLoaded = true;
      console.log(resultData);
      this.ListArray = resultData;
    });
  }

  setUpdate(data: any) {
    this.currentListID = data.id;
    this.router.navigate(['/edit-task', this.currentListID]);
  }

  setDelete(data: any) {
    this.http.delete("http://localhost:5031/api/ToDoList/DeleteList" + "/" + data.id).subscribe(
      (resultData: any) => {
        console.log(resultData);
        alert("Task Deleted");
        this.getAllList();
      },
      (error) => {
        console.error(error);
        alert("Error deleting task");
      }
    );
  }

  navigateToAddTask() {
    this.router.navigate(['/add-task']);
  }
}
