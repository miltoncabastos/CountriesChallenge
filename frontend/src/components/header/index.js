import { connect, useDispatch } from 'react-redux'
import {
    AppBar,
    Toolbar,
    IconButton,
    fade,
    makeStyles,
    Typography,
    InputBase
} from '@material-ui/core'
import { fetchSearchCountry } from '../../redux/actions'

import SearchIcon from '@material-ui/icons/Search'
import AccountCircle from '@material-ui/icons/AccountCircle';

const useStyles = makeStyles((theme) => ({
    root: {
        flexGrow: 1,
    },
    menuButton: {
        marginRight: theme.spacing(2),
    },
    title: {
        flexGrow: 1,
    },
    search: {
        position: 'relative',
        borderRadius: theme.shape.borderRadius,
        backgroundColor: fade(theme.palette.common.white, 0.15),
        '&:hover': {
            backgroundColor: fade(theme.palette.common.white, 0.25),
        },
        marginRight: theme.spacing(2),
        marginLeft: 0,
        width: '100%',
        [theme.breakpoints.up('sm')]: {
            marginLeft: theme.spacing(3),
            width: 'auto',
        },
    },
    searchIcon: {
        padding: theme.spacing(0, 2),
        height: '100%',
        position: 'absolute',
        pointerEvents: 'none',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center',
    },
    inputRoot: {
        color: 'inherit',
    },
    inputInput: {
        padding: theme.spacing(1, 1, 1, 0),
        paddingLeft: `calc(1em + ${theme.spacing(4)}px)`,
        transition: theme.transitions.create('width'),
        width: '100%',
        [theme.breakpoints.up('md')]: {
            width: '20ch',
        },
    },
}));

function CardCountry() {
    const classes = useStyles();
    
    const dispatch = useDispatch();

    function updateSearch(value){
        dispatch(fetchSearchCountry(value));
    }

    return (
        <div className={classes.root}>
            <AppBar position="static">
                <Toolbar>                    
                    <Typography variant="h6" className={classes.title} noWrap>
                        Countries Challenger
                    </Typography>
                    <div className={classes.search}>
                        <div className={classes.searchIcon}>
                            <SearchIcon />
                        </div>
                        <InputBase
                            placeholder="Search…"
                            classes={{
                                root: classes.inputRoot,
                                input: classes.inputInput,
                            }}
                            inputProps={{ 'aria-label': 'search' }}
                            onChange={(event => updateSearch(event.target.value))}
                        />
                    </div>
                    <IconButton color="inherit" edge="end">
                        <AccountCircle/>
                    </IconButton>
                </Toolbar>
            </AppBar>
        </div>
    )
}

export default connect()(CardCountry);