import Title from "@/components/Title"
import {
  Table,
  TableBody,
  TableCaption,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table"
import { useEffect } from "react";


export default function Dashboard() {

  useEffect(() => {
    document.title = "Admin | Embarc Parking";
  });
  return (
    <div>
      <Title/>
        <Table className="w-[700px] rounded-[10px] max-h-96 bg-[#3d3d3d]">
          <TableCaption className="text-white">Painel Geral</TableCaption>    
          <TableHeader>
            <TableRow>
              <TableHead className="w-[100px] rounded-tl-[10px] text-white font-medium">Placa</TableHead>
              <TableHead className="text-white font-medium">Status</TableHead>
              <TableHead className="text-white font-medium">Tempo</TableHead>
              <TableHead className="text-right rounded-tr-[10px] text-white font-medium">Quantia</TableHead>
            </TableRow>
          </TableHeader>
        <TableBody>
          <TableRow>
            <TableCell className="rounded-bl-[10px] text-[#9e9e9e]">INV001</TableCell>
            <TableCell className="text-[#9e9e9e]">Pendente</TableCell>
            <TableCell className="text-[#9e9e9e]">1:30:00</TableCell>
            <TableCell className="text-right rounded-br-[10px] text-[#9e9e9e]">R$8,00</TableCell>
          </TableRow>
        </TableBody>
    </Table>
  </div>
  )
}