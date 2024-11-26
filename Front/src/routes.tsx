import { Routes, Route } from "react-router";
import App from "./App";
import PaymentPage from "./pages/PaymentPage";

export default function MainRoutes(){
  return(
    <Routes>
      <Route path="/" element={<App/>} />
      <Route path="/payment" element={<PaymentPage/>} />
    </Routes>
  )
}