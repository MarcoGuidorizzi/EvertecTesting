import { useState } from "react";

function PontoForm({ initialData, onSave }) {
    const [form, setForm] = useState(
        initialData || { nome: "", localizacao: "", cidade: "", estado: "", descricao: "" }
    );

    const handleChange = (e) => {
        setForm({ ...form, [e.target.name]: e.target.value });
    };

    const handleSubmit = () => {
        if (
            !form.nome.trim() ||
            !form.localizacao.trim() ||
            !form.cidade.trim() ||
            !form.estado.trim() ||
            !form.descricao.trim()
        ) {
            alert("Por favor, preencha todos os campos obrigatórios.");
            return;
        }

        onSave(form);
    };

    return (
        <div>
            <h2 className="text-xl font-bold mb-4">
                {initialData ? "Editar Ponto Turístico" : "Cadastrar Ponto Turístico"}
            </h2>
            <div className="space-y-2">
                <input name="nome" placeholder="Nome" value={form.nome} onChange={handleChange} className="border p-2 w-full rounded" required />
                <input name="localizacao" placeholder="Localização" value={form.localizacao} onChange={handleChange} className="border p-2 w-full rounded" required />
                <input name="cidade" placeholder="Cidade" value={form.cidade} onChange={handleChange} className="border p-2 w-full rounded" required />
                <input name="estado" placeholder="Estado" value={form.estado} onChange={handleChange} className="border p-2 w-full rounded" required />
                <textarea name="descricao" placeholder="Descrição" value={form.descricao} onChange={handleChange} className="border p-2 w-full rounded" required />
            </div>
            <button
                onClick={handleSubmit}
                className="mt-4 bg-blue-500 hover:bg-blue-600 text-white px-4 py-2 rounded transition-colors"
            >
                {initialData ? "Salvar Alterações" : "Cadastrar"}
            </button>
        </div>
    );
}

export default PontoForm;
