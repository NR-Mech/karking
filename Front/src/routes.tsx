import { Routes, Route } from "react-router";
import App from "./App";
import PaymentPage from "./pages/PaymentPage";
import { Paid } from "./pages/Paid";

export default function MainRoutes() {
  return (
    <Routes>
      <Route path="/" element={<App />} />
      <Route path="/payment" element={<PaymentPage />} />
      <Route path="/paid" element={<Paid />} />
    </Routes>
  );
}
