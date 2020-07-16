import React, {useState, useEffect} from 'react'
import axios from 'axios'
import {Grid, List, Image} from 'semantic-ui-react'

const RunningContainersList = () => {
    const [data, setData] = useState({Other: []})

    useEffect(() => {
        const fetchData = async () => {
            const result = await axios(
                'runningcontainers'
            )

            console.log(`data: ${JSON.stringify(result.data)}`)
            setData(result.data);
        }

        fetchData();
    }, [])

    if (data.Other) {
        return (
            <Grid celled>

                {data.Other?.map(item => (
                    <Grid.Row>
                        <Grid.Column width={3}>
                            <Image src='https://react.semantic-ui.com/images/wireframe/image.png' />
                        </Grid.Column>
                        <Grid.Column width={13}>
                            <List.Item key={item.Names}>
                                Image: {item.Image} <br/>
                                Name: {item.Names}<br/>
                                Ports: {item.Ports}<br/>
                            </List.Item>
                        </Grid.Column>
                    </Grid.Row>
                ))}
            </Grid>
        )
    }
    return (
        <div>
            Nothing
        </div>
    )
}

export default RunningContainersList
     

