import React, {useState, useEffect} from 'react'
import axios from 'axios'

export default () => {
    const [containers, setContainers] = useState({})
    
    const fetchContainers = async () => {
        const response = await fetch('stuff')
        const data = await response.json()
        console.log(data)
        // this.setState({stuff: data, loading: false})
        setContainers(data)
    }
    
    useEffect(() => {
        fetchContainers()
    },[])
    
    const renderedContainers = Object.values(containers).map(container => {
        console.log(container)
        return (
            <div key={container.id}>
                <div>
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
