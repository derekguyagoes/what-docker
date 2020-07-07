import React, {useState, useEffect} from 'react'
import axios from 'axios'

export default () => {
    const [containers, setContainers] = useState([])
    
    const fetchContainers = async () => {
        const res = await axios.get('runningcontainers')        
        setContainers(res.data)
        console.log(`data: ${JSON.stringify(containers)}`)
    }
    
    useEffect(() => {
        fetchContainers()
    },[])   
    
    
    // const renderedContainers = Object.values(containers).map(container => {
    //     console.log(container)
    //     return (
    //         <div
    //             className="card"
    //             style={{width: '30%', marginBottom: '20px'}}
    //             key={container.id}>
    //             <div className="card-body">
    //                 <h3>name: {container}</h3>
    //             </div>
    //         </div>
    //     )
    // })   
    
    // const renderedContainers = containers.map((container, index) => {
    //     return <li key={container.Name}>{container}</li>
    // })
    
    
    return (
        <>
            <ul>
                {containers.map(container => (
                    <li key={container.Name}>{container}</li>
                ))}
            </ul>    
        </>
            
        // <div className="d-flex flex-row flex-wrap justify-content-between">
        //     {/*{containers.map(container => <li>{container}</li>)}*/}
        //     {renderedContainers} 
        // </div>    
    )
}
