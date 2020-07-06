import React, {useState, useEffect} from 'react'
import axios from 'axios'

export default () => {
    const [containers, setContainers] = useState({})
    
    const fetchContainers = async () => {
        const res = await axios.get('runningcontainers')        
        setContainers(res.data)
    }
    
    useEffect(() => {
        fetchContainers()
    },[])
    
    const renderedContainers = Object.values(containers).map(container => {
        console.log(container)
        return (
            <div
                className="card"
                style={{width: '30%', marginBottom: '20px'}}
                key={container.id}>
                <div className="card-body">
                    name: {container}
                </div>
            </div>
        )
    })   
    
    return (
        <div>
            {renderedContainers}            
        </div>    
    )
}
