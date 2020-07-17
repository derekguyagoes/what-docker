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
                <Grid.Row>
                    <Grid.Column width={3}>
                        <Image src='https://react.semantic-ui.com/images/wireframe/image.png'/>
                    </Grid.Column>
                    <Grid.Column width={13}>
                        {data.Other?.map(item => (
                            <List.Item key={item.Names} sty>
                                <b>Image:</b> {item.Image} <b>Name:</b> {item.Names} <b>Ports:</b> {item.Ports}
                            </List.Item>
                        ))}
                    </Grid.Column>
                </Grid.Row>
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
     

