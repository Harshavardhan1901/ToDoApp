import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css'],
})
export class TodoListComponent {
  ListArray : any[] = [];
  isResultLoaded = false;
  isUpdateFormActive = false;

  title: string ="";
  description: string ="";
  serialNumber: number = 1;
 
  currentListID = "";

  constructor(private http: HttpClient ) 
  {
    this.getAllList();
  }

  ngOnInit(): void {
  }

  getAllList() {
    this.http.get("http://localhost:5031/api/ToDoList/GetList")
      .subscribe((resultData: any) => {
        this.isResultLoaded = true;
        this.ListArray = resultData.map((item: any, index: number) => ({
          ...item,
          serialNumber: index + 1,
        }));
      });
  }

  register()
  {
   // this.isLogin = false; 
   // alert("hi");
    let bodyData = {
      "title" : this.title,
      "description" : this.description,
    
    };

    this.http.post("http://localhost:5031/api/ToDoList/AddList",bodyData).subscribe((resultData: any)=>
    {
        console.log(resultData);
        alert("Task Noted Successfully")
        this.getAllList();
    });
  }

  setUpdate(data: any) 
  {
   this.title = data.title;
   this.description = data.description;
   

   this.currentListID = data.id;
 
  }

  UpdateRecords()
  {
    let bodyData = 
    {
      "id": this.currentListID,
      "title" : this.title,
      "description" : this.description,
    };
    
    this.http.patch("http://localhost:5031/api/ToDoList/UpdateList"+ "/"+ this.currentListID,bodyData).subscribe((resultData: any)=>
    {
        console.log(resultData);
        alert("Task Updateddd")
        this.resetForm();
        this.getAllList();
      
    });
  }
 
  save()
  {
    if(this.currentListID == '')
    {
      this.register();
    }
    else
    {
      this.UpdateRecords();
    }       
    this.resetForm();
  }

  resetForm() {
    this.title = "";
    this.description = "";
    this.currentListID = "";
  }

  setDelete(data: any)
  {
    this.http.delete("http://localhost:5031/api/ToDoList/DeleteList"+ "/"+ data.id).subscribe((resultData: any)=>
    {
        console.log(resultData);
        alert("Task Deletedddd")
        this.getAllList();
    });
  }
}