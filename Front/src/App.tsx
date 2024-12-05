import { useState } from "react";
import Button from "./components/Button";
import Container from "./components/Container";
import Input from "./components/Input";
import Title from "./components/Title";
import { useNavigate } from "react-router";

function App() {
  const navigate = useNavigate();

  const [placa, setPlaca] = useState("");

  const consulte = async () => {
    try {
      // Simulação de uma requisição GET
      const response = await fetch(
        `https://karking-api.zaqbit.com/vehicles/${placa}`,
        {
          method: "GET",
          headers: {
            "Content-Type": "application/json",
            "X-API-Key": import.meta.env.VITE_API_KEY,
          },
        }
      );
      const data = await response.json();

      navigate("/payment", { state: { placaInfo: data } });
    } catch (error) {
      console.error("Erro ao buscar os dados:", error);
    }
  };

  return (
    <Container>
      <Title />
      <Input
        content="Placa"
        value={placa}
        onChange={(e) => setPlaca(e.target.value)}
      />
      <Button content="Consultar" onClick={consulte} />
    </Container>
  );
}

export default App;
