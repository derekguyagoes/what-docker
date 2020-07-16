import React from 'react';
import {Container, Header, List} from "semantic-ui-react"
import RunningContainersList from './components/RunningContainersList'

import './custom.css'

export default () => {
    return <Container style={{margin:20}}>
        <Header>
            WhatDocker?
        </Header>            
        <RunningContainersList />
        
    </Container>
}
