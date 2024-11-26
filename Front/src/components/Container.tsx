type ContainerProps = {
  children: React.ReactNode;
};

export default function Container({ children }: ContainerProps) {
  return (
    <div className="mx-[450px] p-5 flex flex-col items-center">
      {children}
    </div>
  );
}