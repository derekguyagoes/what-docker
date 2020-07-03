import React, {Component} from 'react'

export class What extends Component {
    constructor(props) {
        super(props);
        this.state = {stuff:[], loading: true}
    }
    
    componentDidMount() {
        this.populateSomethingData()
    }

    render() {
        let contents = this.state.loading
        ? <p><em>Loading...</em></p>
        : this.state.stuff
        
        return (
            <div>
                <h1>What</h1>
                <h1>first: {contents}</h1>
            </div>
        );
    }
    
    async populateSomethingData(){
        const response = await fetch('stuff')
        const data = await response.json()
        console.log(data)
        this.setState({stuff: data, loading: false})
    }
}