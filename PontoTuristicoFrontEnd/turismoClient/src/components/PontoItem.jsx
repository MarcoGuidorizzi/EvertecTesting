function PontoItem({ ponto, onEdit, onDelete }) {
    return (
        <li className="border-b py-2 flex justify-between items-center">
            <div>
                <h2 className="font-bold">{ponto.nome}</h2>
                <p>{ponto.descricao}</p>
                <small>{ponto.localizacao} - {ponto.cidade}/{ponto.estado}</small>
            </div>
            <div className="space-x-2">
                <button
                    onClick={() => onEdit(ponto)}
                    className="bg-yellow-500 text-white px-3 py-1 rounded"
                >
                    Editar
                </button>
                <button
                    onClick={() => onDelete(ponto.id)}
                    className="bg-red-500 text-white px-3 py-1 rounded"
                >
                    Remover
                </button>
            </div>
        </li>
    );
}

export default PontoItem;