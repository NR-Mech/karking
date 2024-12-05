import hourIcon from '../assets/clock-nine-svgrepo-com 1.svg'
import dollarIcon from '../assets/dollar-svgrepo-com 1.svg'

export default function DisplayPayment() {
  return (
    <div className="bg-[#3d3d3d] w-[270px] rounded-[10px] px-[15px] py-[20px] mb-[30px]">
      <div className='mb-[20px]'>
        <h6 className='text-[1.25rem] text-white font-poppins mb-[5px]'>Tempo</h6>
        <div className='flex gap-[10px] items-center'>
          <img src={hourIcon} alt=""/>
          <span className='text-[1.25rem] text-white font-poppins'>00:00:00</span>
        </div>
      </div>

      <div>
        <h6 className='text-[1.25rem] text-white font-poppins mb-[5px]'>Tarifa</h6>
        <div className='flex gap-[10px] items-center'>
          <img src={dollarIcon} alt=""/>
          <span className='text-[1.25rem] text-white font-poppins'>R$ 0,00</span>
        </div>
      </div>
    </div>
  )
}