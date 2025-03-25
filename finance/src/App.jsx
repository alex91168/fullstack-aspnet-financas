import React, { useState, useEffect } from 'react'
import './App.css'
export default function App() {
const [dbDados, setDbDados] = useState([]);
const [form, setForm] = useState(false);
const url = 'http://localhost:5190/finance/';
const sliceDate = dbDados.slice(0, 4)
  useEffect(() => {
    if (dbDados.length === 0) {
      getdatabase();
    }
  }, []);
  const getdatabase = async () => {
      await fetch(`${url}dados`)
        .then((response) => response.json())
        .then((data) => {
          setDbDados(data);
        })
        .catch((error) => {
          console.error('Erro ao buscar os dados:', error);
        });
  }
  const [newItem, setNewItem] = useState({
    description: '',
    type: '',
    amount: '',
    //date: '',
  });

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setNewItem((prev) => ({ ...prev, [name]: value }));
  };
  const handleSaveDb = async () => {
    const response = await fetch(`${url}create`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(newItem),
      })
      if(response.ok){
        setForm(false)
        //setNewItem({ description: '', type: '', amount: ''
          // , date: '' 
        //});
        await getdatabase();
      }
  }
  console.log(newItem);
  const handleSave = () => {
    if (newItem.description && newItem.type && newItem.amount ) {
      setTeste((prev) => [...prev, { id: prev.length + 1, ...newItem }]);
      setForm(false);
      setNewItem({ description: '', type: '', amount: ''
      // , date: '' 
      });
    }
  };

  return (
    <div id='container-table'>
      <div id='table'>
        <div id='table-container'>
          <div className='table-title'>
            <h2>Despensas Mensais: Janeiro</h2>
          </div>
          <table className='table-box'>
            <thead className='tabled head-tabled'>
              <tr>
                <th className='th-1'>Descrição</th>
                <th className='th-2'>Categoria</th>
                <th className='th-3'>Valor</th>
                <th className='th-4'>Data</th>
                <th className='th-5'></th>
              </tr>
            </thead>
            <tbody>
              {sliceDate.map(item => {
                return(
                  <tr key={item.id} className='tabled body-tabled'>
                    <td className='th-1'>{item.description}</td>
                    <td className='th-2'>{item.type}</td>
                    <td className='th-3'>R$ {(item.amount).toFixed(2)}</td>
                    <td className='th-4'>{item.date}</td>
                    <td className='th-5'>e</td>
                  </tr>
                )
              })}
                {form && (
                  <tr className='tabled body-tabled'>
                  <td className='th-1'><input type='text' name='description' value={newItem.description} onChange={handleInputChange} /></td>
                  <td className='th-2'><input type='text' name='type' value={newItem.type} onChange={handleInputChange} /></td>
                  <td className='th-3'><input type='text' name='amount' value={newItem.value} onChange={handleInputChange} /></td>
                  {/**<td className='th-4'><input type='date' name='date' value={newItem.date} onChange={handleInputChange} /></td> */}
                </tr>
                )}
                <tr className='tabled body-tabled button'>
                <td colSpan={5}>
                  {form ? (
                    <>
                      <button onClick={handleSaveDb}>Salvar</button>
                      <button onClick={() => setForm(false)}>Fechar</button>
                    </>
                  ) : (
                    <button onClick={() => setForm(true)}>Novo</button>
                  )}
                </td>
                </tr>
            </tbody>
          </table>
        </div>
      </div>

      <div id='graphics'>
        <div id='graphics-1'>XD</div>
        <div id='graphics-table'>TE</div>
      </div>
    </div>
  )
}
