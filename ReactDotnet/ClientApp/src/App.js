import React from 'react';
import RunningContainersList from './components/RunningContainersList'

import './custom.css'
import {Layout} from "./components/Layout";

export default () => {
    return (  
        <div className="container">
            <RunningContainersList />
        </div>
    )
}
