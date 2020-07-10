import React, {useState, useEffect} from 'react'
import axios from 'axios'

const RunningContainersList = () => {
    const [data, setData] = useState({ Other: [] })

    useEffect(() => {
        const fetchData = async () => {
            const result = await axios(                
                'runningcontainers'
            )

            console.log(`data: ${JSON.stringify(result.data)}`)
            setData(result.data );
        }

        fetchData();
    },[])

    if(data.Other) {
        return (
            <div>
                <ul>
                    {data.Other?.map(item => (
                        <li key={item.Names}>
                            Image: {item.Image} <br/>
                            Name: {item.Names}<br/>
                            Ports: {item.Ports}<br/>
                        </li>
                    ))}
                </ul>
            </div>
        )
    }
    return (
        <div>
            Nothing
        </div>
    )
}

export default RunningContainersList
     

