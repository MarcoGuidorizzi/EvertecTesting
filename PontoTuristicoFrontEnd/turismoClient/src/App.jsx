import { useEffect, useState } from 'react'
import Header from './components/Header'
import PontoList from './components/PontoList'
import Modal from './components/Modal'
import PontoForm from './components/PontoForm'
import './App.css'

function App() {
    const API_URL = "http://localhost:5034/api/pontoturistico";
    const [pontos, setPontos] = useState([]);
    const [modalOpen, setModalOpen] = useState(false);
    const [editData, setEditData] = useState(null);

    //GET - listar pontos
    useEffect(() => {
        fetch(API_URL)
            .then(response => response.json())
            .then(data => setPontos(data))
            .catch(error => console.error('Erro ao buscar pontos turísticos:', error));
    }
        , []);

    const handleSave = async (formData) => {
        if (editData) {

            await fetch(`${API_URL}/${editData.id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(formData)
            });
            setPontos(pontos.map(p => p.id === editData.id ? { ...formData, id: editData.id } : p));
        } else {
            //POST
            const response = await fetch(API_URL, {
                method: 'POST',
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(formData),
            });
            const novo = await response.json();
            setPontos([...pontos, novo]);
        }
        setModalOpen(false);
        setEditData(null);
        };

    //DELETE
    const handleDelete = async (id) => {
        await fetch(`${API_URL}/${id}`, { method: 'DELETE' });
        setPontos(pontos.filter(p => p.id !== id));
    };
    return (
        <div className="min-h-screen bg-gray-100">
            <Header onAdd={() => setModalOpen(true)} />
            <div className="p-6">
                <PontoList
                    pontos={pontos}
                    onEdit={(p) => { setEditData(p); setModalOpen(true); }}
                    onDelete={handleDelete}
                />
            </div>

            {modalOpen && (
                <Modal onClose={() => { setModalOpen(false); setEditData(null); }}>
                    <PontoForm
                        initialData={editData}
                        onSave={handleSave}
                    />
                </Modal>
            )}
        </div>
    );
}
export default App
