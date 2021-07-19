import React, { useState, useEffect } from 'react'
import ApiAxios from '../utils/ApiAxios'

const List = () => {

    const [loading, setLoading] = useState(false)
    const [error, setError] = useState(null)
    const [transacciones, setTransacciones] = useState([])
    

    let getTransactions = async () => {
        let currentDate = new Date()
        currentDate = currentDate.toISOString().split('T')[0]
        setLoading(true)
        const jsonBody = {
            from:currentDate,
            to: currentDate
        }
        try {
          await ApiAxios.post(`api/transactions/filter`, jsonBody).then((res) => {
            console.log(res.data)
            if (res.hasOwnProperty('data')) {
              setLoading(false)
              setError(null)
              setTransacciones(res.data)
              console.log(transacciones)
            } else {
              console.log('no se pudo obtener transacciones.', res.data)
            }
          })
        } catch (error) {
          setLoading(false)
          setError(error)
        }
      }

      useEffect(() => {
        getTransactions()
      }, [])

    return (
        <table className="table">
        <thead>
            <tr>
            <th scope="col">Fecha</th>
            <th scope="col">Cuenta</th>
            <th scope="col">Descripción</th>
            <th scope="col">Total</th>
            </tr>
        </thead>
        <tbody>
          {transacciones.map((transaccion)=> (
            <tr key={transaccion.uuid.timestamp}>
                <th scope="row">{transaccion.date}</th>
                <td>{transaccion.account}</td>
                <td>{transaccion.description}</td>
                <td>{transaccion.total}</td>
            </tr>
          ))}
        </tbody>
        </table>
    );
};

export default List;