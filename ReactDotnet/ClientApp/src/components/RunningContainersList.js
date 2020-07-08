import React, {useState, useEffect} from 'react'
import axios from 'axios'

const items = [
    {title: 'what is?', content: 'front end'},
    {title: 'why use?', content: 'favorite'},
    {title: 'how use?', content: 'you are'},
]

const RunningContainersList = () => {
    const [data, setData] = useState({ Other: [] })

    useEffect(() => {
        const fetchData = async () => {
            const result = await axios(                
                'runningcontainers'
            )

            setData(result.data);
        }

        fetchData();
    },[])

    return (

        <div>            
            
            <ul>
                {data.Other.map(item => (
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

export default RunningContainersList
     

