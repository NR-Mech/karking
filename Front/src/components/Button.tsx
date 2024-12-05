type buttonProps = {
  content: string;
  onClick?: () => void
}

export default function Button({content, onClick}: buttonProps){
  return(
    <div>
      <button onClick={onClick} className="bg-gradient-to-b from-[#E67D1A] to-[#CB5C14] text-[#411307] font-poppins font-semibold text-base tracking-wide py-2 px-6 rounded-[5px] uppercase cursor-pointer">{content}</button>
    </div>
  )
}