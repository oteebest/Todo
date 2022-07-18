import { stringify } from "querystring";
import React, { FormEvent, useEffect, useState } from "react";
import styled from "styled-components";
import { TaskRequestModel } from "../Model/Request/TaskRequestModel";
import { UserResponseModel } from "../Model/Response/UserResponseModel";
import { TodoApi } from "../Service/TodoApiService";
import PagedTaskResponseModel from "../Model/Response/PagedTaskResponseModel";

export interface FormProps {
  taskId: string;
  setOpenModal: (open: boolean) => void;
  ReloadTask: (tasks: PagedTaskResponseModel) => void;
}

interface FormState {
  title: string;
  description: string;
  todoUserId: string;
}
export const Form: React.FC<FormProps> = ({
  taskId,
  setOpenModal,
  ReloadTask,
}: FormProps) => {
  const [fromProps, setFormProps] = useState<FormProps>(() => ({
    taskId,
    setOpenModal,
    ReloadTask,
  }));

  const [formState, setFormState] = useState<FormState>({
    title: "",
    description: "",
    todoUserId: "",
  });

  const [users, setUsers] = useState<Array<UserResponseModel>>([]);

  useEffect(() => {
    async function GetUsers() {
      var response = await TodoApi.getUsers();
      setUsers(response.data.data as Array<UserResponseModel>);
    }

    GetUsers();
  }, []);

  useEffect(() => {
    if (taskId === "") {
      console.log("dont get task");
      return;
    }

    async function GetTask() {
      const response = await TodoApi.getTask(taskId);
      setFormState(response.data.data);
    }
    GetTask();
  }, []);

  async function handleSubmit(e: FormEvent) {
    e.preventDefault();
    const taskRequestModel = formState as TaskRequestModel;

    if (taskId) {
      await TodoApi.updateTask(taskId, taskRequestModel);
    } else {
      await TodoApi.createTask(taskRequestModel);
    }

    var response = await TodoApi.getTasks();
    ReloadTask(response.data.data);
    setOpenModal(false);
  }

  return (
    <form onSubmit={handleSubmit}>
      <label htmlFor="title">Title:</label>
      <br />
      <input
        type="text"
        id="title"
        name="title"
        onChange={(e) =>
          setFormState({ ...formState, title: e.currentTarget.value })
        }
        value={formState.title}
      />
      <br />
      <label htmlFor="description">Description:</label>
      <br />
      <input
        type="text"
        id="description"
        name="description"
        onChange={(e) =>
          setFormState({ ...formState, description: e.currentTarget.value })
        }
        value={formState.description}
      />
      <label htmlFor="taskUser">Task Owner:</label>
      <br />
      <select
        id="taskUser"
        onChange={(e) =>
          setFormState({ ...formState, todoUserId: e.currentTarget.value })
        }
        name="taskUser"
        value={formState.todoUserId}
      >
        <option disabled>Select User</option>
        {users.map((u) => (
          <option value={u.id} key={u.id}>
            {u.name}
          </option>
        ))}
      </select>

      <FormButtonWrapperComponent>
        <button
          type="button"
          onClick={() => {
            fromProps.setOpenModal(false);
          }}
          id="cancelBtn"
        >
          Cancel
        </button>
        <button type="submit">Continue</button>
      </FormButtonWrapperComponent>
    </form>
  );
};

const FormButtonWrapperComponent = styled.div`
  flex: 20%;
  display: flex;
  justify-content: center;
  align-items: center;

  button {
    width: 150px;
    height: 45px;
    margin: 10px;
    border: none;
    background-color: cornflowerblue;
    color: white;
    border-radius: 8px;
    font-size: 20px;
    cursor: pointer;
  }

  button .cancelBtn {
    background-color: crimson;
  }
`;
