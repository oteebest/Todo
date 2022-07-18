import { UserResponseModel } from "./UserResponseModel";

export default interface TaskResponseModel {
  status: number;
  todoUserId: string;
  title: string;
  description: string;
  id: string;
  createdOn: Date;
  todoUser: UserResponseModel;
}
