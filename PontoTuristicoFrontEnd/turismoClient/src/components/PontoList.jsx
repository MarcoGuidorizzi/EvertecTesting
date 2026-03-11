import PontoItem from "./PontoItem";

function PontoList({ pontos, onEdit, onDelete }) {
    if (pontos.length === 0) {
        return <p className="text-red-500">Não encontrei nenhum resultado :(</p>;
    }
    return (
        <ul>
            {pontos.map(p => (
                <PontoItem key={p.id} ponto={p} onEdit={onEdit} onDelete={onDelete} />
            ))}
        </ul>
    );
}

export default PontoList;