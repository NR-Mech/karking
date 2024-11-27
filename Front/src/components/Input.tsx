import brazilFlag from "../assets/emojione-v1_flag-for-brazil.svg";

type InputProps = {
  content: string;
  value: string;
  onChange?: (event: React.ChangeEvent<HTMLInputElement>) => void;
};

export default function Input({ content }: InputProps) {
  return (
    <div className="mb-[30px]">
      <label
        htmlFor="input"
        className="font-poppins text-white text-[1.25rem] mb-[5px]"
      >
        {content}
      </label>
      <div className="w-52 py-1 bg-[#08399C] relative rounded-t-[5px]">
        <h6 className="font-poppins text-white text-xs font-semibold text-center">
          BRASIL
        </h6>
        <img src={brazilFlag} alt="" className="absolute top-[2px] right-1" />
      </div>
      <input placeholder="BRA3R52" type="text" maxLength={7} name="input" id="input" className="w-52 py-3 text-center outline-none font-pt-sans-narrow text-[1.25rem] uppercase rounded-b-[5px]" />
    </div>
  );
}
