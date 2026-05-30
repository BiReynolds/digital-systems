var centerPanel = document.getElementById("center-panel");
var board = document.getElementById("board");
var boardSize = Math.min(centerPanel.offsetWidth, centerPanel.offsetHeight);

var NumRows = 10;
var CellsPerRow = 10;

var CellSize = Math.min(boardSize / CellsPerRow, boardSize / NumRows);

InitializeBoard(NumRows, CellsPerRow);

function InitializeBoard(numRows, numCellsPerRow) {
    board.style.width = boardSize.toString() + "px";
    board.style.height = boardSize.toString() + "px";
    for (let row = 0; row < numRows; row++) {
        if (row == numRows - 1) {
            board.appendChild(GetEmptyBoardRow(numCellsPerRow, true));
        }
        else {
            board.appendChild(GetEmptyBoardRow(numCellsPerRow, false));
        }
    }
}

function GetEmptyBoardRow(numCells, isLatestRow = false) {
    var isCellActiveArray = new Array(numCells).fill(0);
    return GetBoardRow(isCellActiveArray, isLatestRow);
}

function GetBoardRow(isCellActiveArray, isLatestRow = false) {
    // general setup
    let result = document.createElement("div");
    result.style.height = CellSize.toString() + "px";
    result.style.width = "100%";
    result.classList.add("board-row");
    if (isLatestRow) {
        result.classList.add("latest")
    }
    // adding cells
    for (let i = 0; i < isCellActiveArray.length; i++) {
        result.appendChild(GetCell(isCellActiveArray[i]));
    }
    return result;
}

function GetCell(isActive) {
    let result = document.createElement("div");
    result.style.height = "100%";
    result.style.width = CellSize.toString() + "px";
    result.classList.add("cell");
    if (isActive) {
        result.classList.add("active")
    }
    return result;
}