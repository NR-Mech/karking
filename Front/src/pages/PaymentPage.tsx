import Title from "../components/Title"
import Container from "../components/Container"
import Input from "../components/Input"
import Button from "../components/Button"
import DisplayPayment from "../components/DisplayPayment"

export default function PaymentPage(){
  return(
    <Container>
      <Title/>
      <Input content=""/>
      <DisplayPayment/>
      <Button content="efetuar pagamento"/>
    </Container>
  )
}