import React, { useEffect, useState } from "react";
import "./App.css";
import styled from "styled-components";
import Header from "./Components/Header";
import Main from "./Components/Main";
import Footer from "./Components/Footer";
import Modal from "./Components/Modal";
import { TodoApi } from "./Service/TodoApiService";
import PagedTaskResponseModel from "./Model/Response/PagedTaskResponseModel";

function App() {
  const [modalOpen, setModalOpen] = useState<boolean>(false);
  const [taskId, setTaskId] = useState<string>("");

  const [tasks, setTasks] = useState<PagedTaskResponseModel>(
    {} as PagedTaskResponseModel
  );

  useEffect(() => {
    async function fetchTasks() {
      var response = await TodoApi.getTasks();
      setTasks(response.data.data as PagedTaskResponseModel);
    }

    fetchTasks();
    console.log("fetching tasks");
  }, []);

  function handleTaskEditOpen(id: string) {
    setTaskId(id);
    setModalOpen(true);
  }

  function handleTaskOpen() {
    setTaskId("");
    setModalOpen(true);
  }

  return (
    <Wrapper>
      <Header></Header>
      <Main
        tasks={tasks}
        handleTaskEditOpen={handleTaskEditOpen}
        handleTaskOpen={handleTaskOpen}
        setModalOpen={setModalOpen}
        setTasks={setTasks}
      ></Main>
      <Footer></Footer>
      {modalOpen && (
        <Modal
          setTasks={setTasks}
          taskId={taskId}
          setOpenModal={setModalOpen}
        ></Modal>
      )}
    </Wrapper>
  );
}

const Wrapper = styled.div`
  display: flex;
  flex-direction: column;
  height: 100%;
`;

export default App;
