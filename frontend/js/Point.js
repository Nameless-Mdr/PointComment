const drawPoints = document.querySelector(".points__draw");

const pointX_Axis = document.querySelector(".new-point-x")
const pointY_Axis = document.querySelector(".new-point-y")
const pointRadius = document.querySelector(".new-point-radius")
const pointColor = document.querySelector(".new-point-color")

const addNewPoint = document.querySelector(".point__add")

var point = new Point();

drawPoints.addEventListener("click", () => point.DrawPoint());

pointX_Axis.addEventListener('change', (e) => point.statePoint.newPoint.x_Axis = e.target.value);
pointY_Axis.addEventListener('change', (e) => point.statePoint.newPoint.y_Axis = e.target.value);
pointRadius.addEventListener('change', (e) => point.statePoint.newPoint.Radius = e.target.value);
pointColor.addEventListener('change', (e) => point.statePoint.newPoint.Color = e.target.value);

addNewPoint.addEventListener('click', () => {
    if(pointX_Axis.value === '' || pointY_Axis.value === '' || pointRadius.value === '' || pointColor.value === '') {
        alert("Все поля должны быть обязательно заполнены!");
    }
    else {
        point.CreatePoint();
    }

    CleanDataPoint();
})

const CleanDataPoint = () => {
    pointX_Axis.value = '';
    pointY_Axis.value = '';
    pointRadius.value = '';
    pointColor.value = '';
}