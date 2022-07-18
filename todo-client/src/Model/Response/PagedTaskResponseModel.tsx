import TaskResponseModel from "./TaskResponseModel";

export default interface PagedTaskResponseModel {
  pageNumber: number;
  pageSize: number;
  totalSize: number;
  items: Array<TaskResponseModel>;
}
