import Button from "./components/Button"
import Container from "./components/Container"
import Input from "./components/Input"
import Title from "./components/Title"
import { useNavigate } from "react-router";

function App() {
  const navigate = useNavigate();

  const consulte = () => {
    navigate('/payment')
  }

    return (
      <Container>
        <Title/>
        <Input content="Placa"/>
        <Button content="Consultar" onClick={consulte}/>
      </Container>
    )
}

export default App
