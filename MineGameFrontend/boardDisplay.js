class BoardDisplay extends HTMLDivElement
{
    static observedAttributes = ["width", "height"]

    connected = false;

    constructor()
    {
        super();
    }

    // CALLBACKS
    connectedCallback()
    {
        this.update(this.getWidth(), this.getHeight());
        this.connected = true;
    }

    attributeChangedCallback(name, oldValue, newValue)
    {
        if(this.connected)
        {
            if(newValue == oldValue)
            return;

            if(name == "width")
            {
                this.update(newValue, this.getHeight());
            }

            else if(name == "height")
            {
                this.update(this.getWidth(), newValue);
            }
        }
    }

    // INTERFACE
    setGridSquares(boardArray)
    {
        for (var y = 0; y < boardArray.length; y++)
        {
            for (var x = 0; x < boardArray.length; x++)
            {
                var squareHTML = "";
                if(boardArray[y][x] == 0)
                {
                    //squareHTML = "~";
                }
                else if(boardArray[y][x] == 1)
                {
                    //squareHTML = "X";
                    squareHTML = "<img class=\"boardSquare\" src=\"Images\\mine.png\"></img>";
                }
                else if(boardArray[y][x] == 2)
                {
                    //squareHTML = "+"
                    squareHTML = "<img class=\"boardSquare\" src=\"Images\\heart.png\"></img>";
                }

                this.setGridSquareHTML(x, y, squareHTML);
                this.setGridSquareAttribute(x, y, "style", "grid-column:" + (x + 3).toString() + "; grid-row:" + (y + 1).toString() + ";"); // Add an additional 1 onto column and row for axes labels
            }
        }
    }

    /* Custom hide methods have been implemented because the board-display cannot be hidden due to its display property being set to grid */
    setHidden(value)
    {
        this.setGridAxisLabelAttribute("x", "hidden", value);
        this.setGridAxisLabelAttribute("y", "hidden", value);

        // X axis
        for (var x = 0; x < this.getWidth(); x++)
        {
            this.setGridAxisSquareAttribute("x", x, "hidden", value);
        }

        // Grid + Y axis
        for (var y = 0; y < this.getHeight(); y++)
        {
            this.setGridAxisSquareAttribute("y", y, "hidden", value);

            for (var x = 0; x < this.getWidth(); x++)
            {
                this.setGridSquareAttribute(x, y, "hidden", value);
            }
        }
    }

    hide()
    {
        this.setHidden("true");
    }

    unhide()
    {
        this.setHidden("false");
    }

    // INTERNAL
    getID()
    {
        return this.getAttribute("id");
    }

    getWidth()
    {
        return parseInt(this.getAttribute("width"));
    }

    getHeight()
    {
        return parseInt(this.getAttribute("height"));
    }

    generateGridSquareID(column, row)
    {
        return this.getID() + ":" + column.toString() + "," + row.toString();
    }

    generateAxisLabelID(axis)
    {
        return this.getID() + ":" + axis + "axisLabel";
    }

    generateAxisSquareID(axis, value)
    {
        return this.getID() + ":" + axis + "," + value.toString();
    }

    generateGridHTML(width, height)
    {
        // Axies so player can determine where they are on the board
        var html = "<div id=\"" + this.generateAxisLabelID("x") + "\" style=\"grid-column: 2; grid-row:" + (width + 1).toString() + ";\">X</div>";
        html += "<div id=\"" + this.generateAxisLabelID("y") + "\" style=\"grid-column: 1; grid-row:" + (width + 1).toString() + ";\">Y</div>";
        
        // X axis
        for (var x = 0; x < width; x++)
        {
            html += "<div id=" + this.generateAxisSquareID("x", x) + "></div>\n";
        }

        // The board itself
        for (var y = 0; y < height; y++)
        {
            // Y axis
            html += "<div id=" + this.generateAxisSquareID("y", y) + "></div>\n";

            for (var x = 0; x < width; x++)
            {
                html += "<div id=" + this.generateAxisSquareID(x, y) + "></div>\n";
            }
        }
        return html;
    }

    generateGridCSS(width, height)
    {
        // Table uses two columns for the Y axis and one row for the X axis so the axis labels are distinguishable
        return "display: grid; grid-template-columns: 20px 20px repeat(" + width.toString() + ", 50px); grid-template-rows: repeat(" + height.toString() + ", 50px) 30px;";
    }

    update(width, height)
    {
        // Update HTML, then CSS

        // HTML
        this.innerHTML = this.generateGridHTML(width, height);
        
        // CSS
        this.style = this.generateGridCSS(width, height);

        // Axes CSS
        for (var x = 0; x < width; x++)
        {
            this.setGridAxisSquareHTML("x", x, x.toString());
            this.setGridAxisSquareAttribute("x", x, "style", "grid-column:" + (x + 3).toString() + "; grid-row:" + (height + 1).toString() + ";");
            
        }
        for (var y = 0; y < height; y++)
        {
            this.setGridAxisSquareHTML("y", y, (height - y - 1).toString());
            this.setGridAxisSquareAttribute("y", y, "style", "grid-column: 1; grid-row:" + (y + 1).toString() + ";");
        }
    }

    // Board squares
    setGridSquareHTML(column, row, html)
    {
        var squareID = this.generateGridSquareID(column, row);
        for (var i = 0; i < this.children.length; i++)
        {
            var child = this.children[i];
            if(child.getAttribute("id") == squareID)
            {
                child.innerHTML = html;
                break; // Early break as we only update one square
            }
        }
    }

    setGridSquareAttribute(column, row, attribute, value)
    {
        var squareID = this.generateGridSquareID(column, row);
        for (var i = 0; i < this.children.length; i++)
        {
            var child = this.children[i];
            if(child.getAttribute("id") == squareID)
            {
                child.setAttribute(attribute, value);
                break; // Early break as we only update one square
            }
        }
    }

    // Axes
    setGridAxisSquareHTML(axis, value, html)
    {
        var squareID = this.generateAxisSquareID(axis, value);
        
        for (var i = 0; i < this.children.length; i++)
        {
            var child = this.children[i];
            if(child.getAttribute("id") == squareID)
            {
                child.innerHTML = html;
                break; // Early break as we only update one square
            }
        }
    }

    setGridAxisSquareAttribute(axis, axisValue, attribute, value)
    {
        var squareID = this.generateAxisSquareID(axis, axisValue);
        for (var i = 0; i < this.children.length; i++)
        {
            var child = this.children[i];
            if(child.getAttribute("id") == squareID)
            {
                child.setAttribute(attribute, value);
                break; // Early break as we only update one square
            }
        }
    }

    setGridAxisLabelAttribute(axis, attribute, value)
    {
        var squareID = this.generateAxisLabelID(axis);
        for (var i = 0; i < this.children.length; i++)
        {
            var child = this.children[i];
            if(child.getAttribute("id") == squareID)
            {
                child.setAttribute(attribute, value);
                break; // Early break as we only update one square
            }
        }
    }
}

customElements.define("board-display", BoardDisplay, { extends: "div" });
