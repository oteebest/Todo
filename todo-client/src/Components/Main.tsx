import React, { useEffect, useState } from "react";
import styled from "styled-components";
import PagedTaskResponseModel from "../Model/Response/PagedTaskResponseModel";
import { TodoApi } from "../Service/TodoApiService";

interface Props {
  children?: any | null;
  setModalOpen: (close: boolean, id?: string) => void;
  handleTaskEditOpen: (id: string) => void;
  handleTaskOpen: () => void;
  tasks: PagedTaskResponseModel;
  setTasks: (tasks: PagedTaskResponseModel) => void;
}

const Main: React.FC<Props> = ({
  children,
  setModalOpen,
  handleTaskEditOpen,
  handleTaskOpen,
  tasks,
  setTasks,
}: Props) => {
  function ShowTasks(): any {
    if (!tasks.items) {
      return null;
    }

    return tasks?.items.map((u) => (
      <tr key={u.id}>
        <td>
          <TaskComponent>
            {u.status === 0 ? (
              <PendingStautusComponent>Pending</PendingStautusComponent>
            ) : (
              <CompletedStautusComponent>Completed</CompletedStautusComponent>
            )}

            <TaskDetailsComponent>
              <div> Title: {u.title}</div>
              <div> Description: {u.description}</div>
              <div> Developer: {u.todoUser.name}</div>
            </TaskDetailsComponent>
            <EditComponent>
              <ButtonComponent
                onClick={() => {
                  handleTaskEditOpen(u.id);
                }}
              >
                Edit
              </ButtonComponent>
              <ButtonComponent onClick={() => Delete(u.id)}>
                Delete
              </ButtonComponent>
              <ButtonComponent onClick={() => Complete(u.id)}>
                Complete
              </ButtonComponent>
            </EditComponent>
          </TaskComponent>
        </td>
      </tr>
    ));
  }

  async function Delete(id: string) {
    await TodoApi.deleteTask(id);

    var response = await TodoApi.getTasks();
    setTasks(response.data.data);
  }

  async function Complete(id: string) {
    await TodoApi.completeTask(id);

    var response = await TodoApi.getTasks();
    setTasks(response.data.data);
  }

  return (
    <Wrapper>
      <div>
        <ButtonComponent
          onClick={() => {
            handleTaskOpen();
          }}
        >
          Add New Task
        </ButtonComponent>
      </div>
      <Table>
        <thead></thead>
        <tbody>{ShowTasks()}</tbody>
      </Table>
    </Wrapper>
  );
};

const ButtonComponent = styled.button`
  background-color: #052c24;
  color: white;
  border-radius: 5px;
  padding: 8px;
  box-shadow: none;
  border: none;
`;
const Wrapper = styled.div`
  flex: 1;
  padding: 20px 20px;
  display: flex;
  flex-direction: column;
  align-items: center;
`;

const Table = styled.table`
  width: 700px;
`;

const TaskComponent = styled.div`
  border: 1px solid gray;
  border-radius: 10px;
  min-height: 130px;
  display: flex;
  overflow: hidden;
  margin-top: 10px;
`;

const PendingStautusComponent = styled.div`
  background-color: #3174df;
  width: 100px;
  color: white;
  border-right: 1px solid gray;
`;

const CompletedStautusComponent = styled.div`
  background-color: #15be0f;
  width: 100px;
  color: white;
  border-right: 1px solid gray;
`;

const TaskDetailsComponent = styled.div`
  flex: 1;
`;

const EditComponent = styled.div`
  width: 100px;
  color: white;
  border-right: 1px solid gray;
  display: flex;
  flex-direction: column;
  gap: 5px;
  padding: 5px;
`;

export default Main;
