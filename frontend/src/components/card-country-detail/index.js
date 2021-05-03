import {
    Card,
    CardContent,
    CardMedia,
    CardActions,
    makeStyles,
    Button,
    Grid
} from '@material-ui/core'
import { useState } from 'react';

import { Link } from 'react-router-dom';

import Input from '../input'

const useStyle = makeStyles({
    root: {
        display: 'inline-block',
        margin: '5px',
        padding: '10px',
    },
});


export default function CardCountryDetail({ country, handleSave }) {
    const classes = useStyle();

    const [model, setModel] = useState(country);

    function updateModel(prop, value) {
        const newModel = {
            ...model,
            [prop]: value
        }
        setModel(newModel);
    }    

    return (
        <Card className={classes.root}>
            <Grid container direction="column">
                <CardMedia
                    component="svg"
                    image={model.flag}
                />
            </Grid>
            <CardContent>
                <Grid container justify="center" spacing={2}>
                    <Grid item xs={6}>
                        <Input
                            label="Country"
                            value={model.name}
                            onChange={event => updateModel('name', event.target.value)}
                        />
                    </Grid>
                    <Grid item xs={6}>
                        <Input
                            required
                            label="Capital"
                            value={model.capital}
                            onChange={event => updateModel('capital', event.target.value)}
                        />
                    </Grid>

                    <Grid item xs={6}>
                        <Input
                            label="Top Level Domains"
                            value={model.topLevelDomains}
                            onChange={event => updateModel('topLevelDomains', event.target.value)}
                        />
                    </Grid>

                    <Grid item xs={6}>
                        <Input
                            label="Area"
                            value={model.area}
                            type="number"
                            required
                            onChange={event => updateModel('area', parseFloat(event.target.value))}
                        />
                    </Grid>

                    <Grid item xs={6}>
                        <Input
                            label="Population"
                            value={model.population}
                            type="number"
                            required
                            onChange={event => updateModel('population', parseFloat(event.target.value))}
                        />
                    </Grid>

                    <Grid item xs={6}>
                        <Input
                            label="Population Density"
                            value={model.populationDensity}
                            required
                            type="number"
                            onChange={event => updateModel('populationDensity', parseFloat(event.target.value))}
                        />
                    </Grid>
                </Grid>
            </CardContent>
            <CardActions>
                <Button component={Link} to={`/`} variant="contained" size="large">
                    Back
                </Button>
                <Button variant="contained" color="primary" size="large" onClick={() => handleSave(model)}>
                    Save
                </Button>
            </CardActions>
        </Card>
    )
}