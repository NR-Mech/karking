import hourIcon from '../assets/clock-nine-svgrepo-com 1.svg'

export default function PopupCare(){
  return(
    <div className='bg-[#3d3d3d] w-52 rounded-[10px]'>
      <h6 className='text-white font-poppins text-[1.25rem] text-center block mb-[30px]'>Carência</h6>
      <div className='flex gap-[10px] justify-center items-center'>
        <img src={hourIcon} alt=''/>
        <span className='text-[#F30707] text-[1.25rem]'>10s</span>
      </div>
    </div>
  )
}