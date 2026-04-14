import './App.css';
import NavMenu from './NavMenu';
import Home from './Home';
// Style
import { GlobalStyle } from './GlobalStyle';

function App() {
	return (	
		<>
		<GlobalStyle />
		<header></header>
		<NavMenu />
		<main>
			<Home />
		</main>
		</>
	);
}

export default App;
