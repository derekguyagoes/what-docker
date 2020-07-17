import React, {useState, useEffect} from 'react'
import axios from 'axios'
import {Grid, List, Image, Card, Checkbox} from 'semantic-ui-react'

const Selector = () => {
    const [checkedItems, setCheckedItems] = useState({})
    
    const handleCheck = (event) => {
        setCheckedItems({
            ...checkedItems,
            [event.target.name]: event.target.name
        })
        console.log("checked items: ", checkedItems)
    }
    
    return (
        <div>
            <Checkbox 
                label="staging "
                name="staging"
                onChange={handleCheck}
            /> 
            <Checkbox 
                label="qa "
                name="qa"
                onChange={handleCheck}
            /> 
            <Checkbox 
                label="production "
                name="production"
                onChange={handleCheck}
            /> 
            <Checkbox 
                defaultChecked 
                label="other"
                name="other"
                onChange={handleCheck}
            /> 
        </div>
    )
}

export default Selector