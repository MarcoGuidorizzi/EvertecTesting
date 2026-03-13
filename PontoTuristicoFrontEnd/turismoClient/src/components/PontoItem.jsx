function PontoItem({ ponto, onEdit, onDelete }) {
    return (
        <li className="border-b py-2 flex justify-between items-center">
            <div className="flex-1 pr-4">
                <h2 className="font-bold text-lg">
                    {ponto.nome || "Ponto sem nome"}
                </h2>

                <p className="text-gray-600">
                    {ponto.descricao || "Sem descrição disponível."}
                </p>

                <small className="text-gray-500 block mt-1">
                    {ponto.localizacao}
                    {ponto.cidade && ` - ${ponto.cidade}`}
                    {ponto.estado && `/${ponto.estado}`}
                </small>
            </div>

            <div className="flex space-x-2 shrink-0">
                <button
                    onClick={() => onEdit(ponto)}
                    className="bg-yellow-500 hover:bg-yellow-600 text-white px-3 py-1 rounded transition-colors"
                >
                    Editar
                </button>
                <button
                    onClick={() => onDelete(ponto.id)}
                    className="bg-red-500 hover:bg-red-600 text-white px-3 py-1 rounded transition-colors"
                >
                    Remover
                </button>
            </div>
        </li>
    );
}

export default PontoItem;
