import { useNavigate } from "react-router";
import Button from "../components/Button";

export function Paid() {
  const navigate = useNavigate();
  return (
    <div className="flex flex-col justify-center items-center gap-5">
      <h1 className="text-white text-2xl font-bold">Pagamento Efetuado!</h1>
      <Button content="Voltar" onClick={() => navigate("/")}/>
    </div>
  )
}