function id(idStr)
{

	return document.getElementById(idStr);
	
}

function tag(tagName)
{
	return document.getElementsByTagName(tagName);
}

function domReady(func)
{
	if(domReady.done)
	{
		return func();
	}
	if(domReady.ready)
	{
		domReady.ready.push(func);
	}
	else
	{

		setTimeout(isReady,10);
		window.onLoad=isReady;
		domReady.ready=[func];

	}
}

function isReady()
{
	if(domReady.done)
	{
		retrun ;
	}
	if(document&&document.getElementById&&document.getElementsByTagName&&document.body)
	{
		for(var i=0;i<domReady.ready.length;i++)
		{
			domReady.ready[i]();
		}
		domReady.done=true;
	}
	else
	{
		setTimeout(isReady,10);
	}
}

function stopBubble(e)
{
	if(e&&e.stopPropagation)
	{
		e.stopPropagation();
	}
	else
	{
		if(window.event)
		{
			window.event.cancelBubble=true;
		}
	}
}

function stopDefault(e)
{
	if(e&&e.preventDefault)
	{
		e.preventDefault();
	}
	else
	{
		window.event.returnValue=false;
	}
}

//HTMLElement.prototype.setAttr=function(name,value) {
//     if (!name || name.constructor != String) {
//        return '';
//    }
//    name = { "for": "htmlFor", "class": "className"}[name] || name;
//    if (typeof value != "undefined") {
//        if (this[name]) {
//            this[name] = value;
//        }
//        else {
//            if (this.setAttribute) {
//                this.setAttribute(name,value);
//            }
//        }
//    }    
//}

//HTMLElement.prototype.getAttr=function(name) {
//    if (!name || name.constructor != String) {
//        return '';
//    }
//    name = { "for": "htmlFor", "class": "className"}[name] || name;
//    return this[name]||this.getAttribute(name,value)||'';
//}

//HTMLElement.prototype.getStyle = function (name) {
//    return this.style[name] || this.currentStyle[name] || function () {
//        if (document.defaultView && document.defaultView.getComputedStyle) {
//            name = name.replace(/([A-Z])/g, "-$1");
//            name = name.toLowerCase();
//            var source = document.defaultView.getComputedStyle(elem, "");
//            return source && source.getPropertyValue(name);
//        }
//    } ()||'';
//}

//HTMLElement.prototype.pageX = function () {
//    return this.offsetParent ? this.offsetLeft + this.offsetParent.pageX() : this.offsetLeft;
//}

//HTMLElement.prototype.pageY = function () {
//    return this.offsetParent ? this.offsetTop + this.offsetParent.pageY() : this.offsetTop;
//}

//HTMLElement.prototype.parentX = function () {
//    return this.parentNode == this.offsetParent ? this.offsetLeft : this.pageX() - this.parentNode.pageX();
//}

//HTMLElement.prototype.parentY = function () {
//    return this.parentNode == this.offsetParent ? this.offsetTop : this.pageY() - this.parentNode.pageY();
//}

function createXMLHttpRequest()
{
	var httpRequest=null;
	if(window.XMLHttpRequest)
	{
		httpRequest=new XMLHttpRequest();
	}
	else
	{
		httpRequest=new ActiveXObject("Microsoft.XMLHTTP");
	}
	return httpRequest;
}

function createAsyncHttpRequest(method,url,callback)
{
	var httpRequest=createXMLHttpRequest();
	if(httpRequest)
	{
		httpRequest.open(method,url,true);
		httpRequest.onreadystatechange=function()
		{
			if(httpRequest.readyState==4&&httpRequest.status==200)
			{
				callback(httpRequest.responseText);
			}
		}
	}
	return httpRequest;
}

function createAsyncHttpRequestTimer(method,url,callback,interval,data)
{
	var httpRequest=createAsyncHttpRequest(method,url,callback);
	var timer=null;
	if(httpRequest)
	{
		if(method=="POST")
		{
			timer=setInterval(function()
			{
				if(data.constructor==String)
				{
					httpRequest.send(data)
				}
			},interval);
		}
		else
		{
			timer=setInterval(function()
				{
					httpRequest.send(null);
				},interval);
		}
	}
}

function createAsyncHttpRequestTimeout(method,url,callback,interval,data)
{
	var httpRequest=createXMLHttpRequest();
	if(httpRequest)
	{
		httpRequest.open(method,url,true);
		httpRequest.onreadystatechange=function()
		{
			if(httpRequest.readyState==4&&httpRequest.status==200)
			{
				callback(httpRequest.responseText);
				setTimeout(function(){httpRequest.send(data);},interval)

			}
		}
	}
	httpRequest.send(data);
}

