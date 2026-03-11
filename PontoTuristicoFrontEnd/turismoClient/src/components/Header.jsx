function Header({ onAdd }) {
    return (
        <header className="bg-blue-600 text-white p-4 flex justify-between items-center">
            <div className="flex items-center space-x-2">
                <img src="/logoevertec.png" alt="Logotipo" className="h-10 w-auto" />
                <h1 className="text-xl font-bold">Turismo API</h1>
            </div>
            <button
                onClick={onAdd}
                className="bg-green-500 px-4 py-2 rounded"
            >
                Cadastrar Ponto Turístico
            </button>
        </header>
    );
}

export default Header;
