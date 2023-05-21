function _defineProperty(obj, key, value) {if (key in obj) {Object.defineProperty(obj, key, { value: value, enumerable: true, configurable: true, writable: true });} else {obj[key] = value;}return obj;}const rootElement = document.getElementById('root');

function RepeatButton(props) {
  return /*#__PURE__*/(
    React.createElement("button", {
      "aria-label": "Play again.",
      id: "repeatButton",
      onClick: props.onClick }));
}

function WinningSound() {
  return /*#__PURE__*/(
    React.createElement("audio", { autoplay: "autoplay", className: "player", preload: "false" }, /*#__PURE__*/
    React.createElement("source", { src: "https://andyhoffman.codes/random-assets/img/slots/winning_slot.wav" })));


}

class App extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      winner: null };

    this.finishHandler = this.finishHandler.bind(this);
    this.handleClick = this.handleClick.bind(this);
  }

  handleClick() {
    this.setState({ winner: null });
    this.emptyArray();
    this._child1.forceUpdateHandler();
    this._child2.forceUpdateHandler();
    this._child3.forceUpdateHandler();
  }

  finishHandler(value) {
    App.matches.push(value);

    if (App.matches.length === 3) {
      const { winner } = this.state;
      const first = App.matches[0];
      let results = App.matches.every(match => match === first);
      this.setState({ winner: results });
    }
  }

  emptyArray() {
    App.matches = [];
  }

  render() {
    const { winner } = this.state;
    const getLoser = () => {
      return;
    };
    let repeatButton = null;
    let winningSound = null;

    if (winner !== null) {	
      repeatButton = /*#__PURE__*/React.createElement(RepeatButton, { onClick: this.handleClick });	
      mp.trigger("client::ruletzavrti", 100);	
    }	
    if (winner) {	
      winningSound = /*#__PURE__*/React.createElement(WinningSound, null);	
      mp.trigger("client::ruletpobeda", 5000);	
    }

    return /*#__PURE__*/(
      React.createElement("div", null,
      winningSound, /*#__PURE__*/
      React.createElement("h1", { style: { color: 'white' } }, /*#__PURE__*/
      React.createElement("span", null, winner === null ? '' : winner ? 'JACKPOT! 🤑' : getLoser())), /*#__PURE__*/


      React.createElement("div", { className: `spinner-container` }, /*#__PURE__*/
      React.createElement(Spinner, { onFinish: this.finishHandler, ref: child => {this._child1 = child;}, timer: "1000" }), /*#__PURE__*/
      React.createElement(Spinner, { onFinish: this.finishHandler, ref: child => {this._child2 = child;}, timer: "1400" }), /*#__PURE__*/
      React.createElement(Spinner, { onFinish: this.finishHandler, ref: child => {this._child3 = child;}, timer: "2200" }), /*#__PURE__*/
      React.createElement("div", { className: "gradient-fade" })),

      repeatButton));


  }}_defineProperty(App, "loser", ['Not quite', 'Stop gambling', 'Hey, you lost!', 'Ouch! I felt that', 'Don\'t beat yourself up', 'There goes the college fund', 'I have a cat. You have a loss', 'You\'re awesome at losing', 'Coding is hard', 'Don\'t hate the coder']);_defineProperty(App, "matches", []);

class Spinner extends React.Component {
  constructor(props) {
    super(props);_defineProperty(this, "state",
























    {
      position: 0,
      lastPosition: null });_defineProperty(this, "multiplier",


    Math.floor(Math.random() * (4 - 1) + 1));_defineProperty(this, "start",

    this.setStartPosition());_defineProperty(this, "speed",
    Spinner.iconHeight * this.multiplier);this.forceUpdateHandler = this.forceUpdateHandler.bind(this);}forceUpdateHandler() {this.reset();}reset() {if (this.timer) {clearInterval(this.timer);}this.start = this.setStartPosition();this.setState({ position: this.start, timeRemaining: this.props.timer });this.timer = setInterval(() => {this.tick();}, 100);}

  setStartPosition() {
    return Math.floor(Math.random() * 9) * Spinner.iconHeight * -1;
  }

  moveBackground() {
    this.setState({
      position: this.state.position - this.speed,
      timeRemaining: this.state.timeRemaining - 100 });

  }

  getSymbolFromPosition() {
    let { position } = this.state;
    const totalSymbols = 9;
    const maxPosition = Spinner.iconHeight * (totalSymbols - 1) * -1;
    let moved = this.props.timer / 100 * this.multiplier;
    let startPosition = this.start;
    let currentPosition = startPosition;

    for (let i = 0; i < moved; i++) {
      currentPosition -= Spinner.iconHeight;

      if (currentPosition < maxPosition) {
        currentPosition = 0;
      }
    }

    this.props.onFinish(currentPosition);
  }

  tick() {
    if (this.state.timeRemaining <= 0) {
      clearInterval(this.timer);
      this.getSymbolFromPosition();

    } else {
      this.moveBackground();
    }
  }

  componentDidMount() {
    clearInterval(this.timer);

    this.setState({
      position: this.start,
      timeRemaining: this.props.timer });


    this.timer = setInterval(() => {
      this.tick();
    }, 100);
  }

  render() {
    let { position, current } = this.state;

    return /*#__PURE__*/(
      React.createElement("div", {
        style: { backgroundPosition: '0px ' + position + 'px' },
        className: `icons` }));


  }}_defineProperty(Spinner, "iconHeight", 188);


function runApp() {
  ReactDOM.render( /*#__PURE__*/
  React.createElement(App, null),
  rootElement);

}

runApp();