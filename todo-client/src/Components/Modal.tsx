import React from "react";
import styled from "styled-components";
import { Form } from "./Form";
import PagedTaskResponseModel from "../Model/Response/PagedTaskResponseModel";

interface Props {
  setOpenModal: (close: boolean, id?: string) => void;
  taskId: string;
  setTasks: (tasks: PagedTaskResponseModel) => void;
}

const Modal: React.FC<Props> = ({ setOpenModal, taskId, setTasks }: Props) => {
  function ReloadTask(tasks: PagedTaskResponseModel) {
    setTasks(tasks);
  }
  return (
    <Wrapper>
      <ContainerComponent>
        <TitleCloseButtonWrapper>
          <TitleCloseButtonComponent
            onClick={() => {
              setOpenModal(false);
            }}
          >
            X
          </TitleCloseButtonComponent>
        </TitleCloseButtonWrapper>
        <Title>
          <h1>Task</h1>
        </Title>
        <ModalContainerBodyComponent>
          <Form
            taskId={taskId}
            ReloadTask={ReloadTask}
            setOpenModal={setOpenModal}
          ></Form>
        </ModalContainerBodyComponent>
        <ModalContainerFooterComponent></ModalContainerFooterComponent>
      </ContainerComponent>
    </Wrapper>
  );
};

const Wrapper = styled.div`
  width: 100vw;
  height: 100vh;
  background-color: rgba(200, 200, 200);
  position: fixed;
  display: flex;
  justify-content: center;
  align-items: center;
`;

const ContainerComponent = styled.div`
  width: 500px;
  height: 500px;
  border-radius: 12px;
  background-color: white;
  box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
  display: flex;
  flex-direction: column;
  padding: 25px;
`;

const Title = styled.div`
  display: inline-block;
  text-align: center;
  margin-top: 10px;
`;

const TitleCloseButtonWrapper = styled.div`
  display: flex;
  justify-content: flex-end;
`;

const TitleCloseButtonComponent = styled.button`
  background-color: transparent;
  border: none;
  font-size: 25px;
  cursor: pointer;
`;

const ModalContainerBodyComponent = styled.div`
  flex: 50%;
  display: flex;
  justify-content: center;
  align-items: center;
  font-size: 1.7rem;
  text-align: center;
`;

const ModalContainerFooterComponent = styled.div`
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

/*   .modalContainer .footer button {
    width: 150px;
    height: 45px;
    margin: 10px;
    border: none;
    background-color: cornflowerblue;
    color: white;
    border-radius: 8px;
    font-size: 20px;
    cursor: pointer;
  } */

/*   #cancelBtn {
    background-color: crimson;
  }
 */
export default Modal;
