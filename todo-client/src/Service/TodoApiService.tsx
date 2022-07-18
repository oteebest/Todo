import axios from "axios";
import { TaskRequestModel } from "../Model/Request/TaskRequestModel";

export class TodoApiService {
  todoApi = axios.create({
    baseURL: "https://localhost:7215",

    headers: {
      "content-type": "application/json",
      "Access-Control-Allow-Origin": "*",
    },
  });

  async getTasks() {
    var response = await this.todoApi.get(
      `api/v1/WorkItems?pageNumber=1&pageSize=1000`
    );
    return response;
  }

  async getTask(id: string) {
    var response = await this.todoApi.get(`api/v1/WorkItems/${id}`);
    return response;
  }

  async getUsers() {
    var response = await this.todoApi.get(`api/v1/Users`);
    return response;
  }

  async getUser(id: string) {
    var response = await this.todoApi.get(`api/v1/Users/${id}`);
    return response;
  }

  async createTask(model: TaskRequestModel) {
    var response = await this.todoApi.post(`api/v1/WorkItems`, model);
    return response;
  }

  async updateTask(id: string, model: TaskRequestModel) {
    var response = await this.todoApi.put(`api/v1/WorkItems/${id}`, model);
    return response;
  }

  async deleteTask(id: string) {
    var response = await this.todoApi.delete(`api/v1/WorkItems/${id}`);
    return response;
  }

  async completeTask(id: string) {
    var response = await this.todoApi.put(`api/v1/WorkItems/complete/${id}`);
    return response;
  }
}

export const TodoApi = new TodoApiService();
