function alarmInfo(alarmValue)
{
	this.alarmValue=alarmValue;
}

alarmInfo.prototype.getFireAlarm=function()
{
	return (this.alarmValue&1)>0;
}

alarmInfo.prototype.getUpOilPlace=function()
{
	return (this.alarmValue&(1<<1))>0;
}

alarmInfo.prototype.getUpWaterPlace=function()
{
	return (this.alarmValue&(1<<2))>0;
}

alarmInfo.prototype.getBatteryVoltage=function()
{
	return (this.alarmValue&(1<<3))>0;
}

alarmInfo.prototype.getAlarmOP1=function()
{
	return (this.alarmValue&(1<<4))>0;
}

alarmInfo.prototype.getAlarmOP2=function()
{
	return (this.alarmValue&(1<<5))>0;
}

alarmInfo.prototype.getAlarmOP3=function()
{
	return (this.alarmValue&(1<<6))>0;
}

alarmInfo.prototype.getAlarmWT1=function()
{
	return (this.alarmValue&(1<<7))>0;
}
alarmInfo.prototype.getAlarmWT2=function()
{
	return (this.alarmValue&(1<<8))>0;
}
alarmInfo.prototype.getAlarmWT3=function()
{
	return (this.alarmValue&(1<<9))>0;
}

alarmInfo.prototype.getAlarmMS1=function()
{
	return (this.alarmValue&(1<<10))>0;
}

alarmInfo.prototype.getAlarmMS2=function()
{
	return (this.alarmValue&(1<<11))>0;
}

alarmInfo.prototype.getAlarmMS3=function()
{
	return (this.alarmValue&(1<<12))>0;
}

alarmInfo.prototype.getOilLeak1=function()
{
	return (this.alarmValue&(1<<13))>0;
}

alarmInfo.prototype.getOilLeak2=function()
{
	return (this.alarmValue&(1<<14))>0;
}

alarmInfo.prototype.getOilLeak3=function()
{
	return (this.alarmValue&(1<<15))>0;
}

alarmInfo.prototype.getAlarmStatus = function () {
    var alarm = this.alarmValue;
    alarm = this.alarmValue << 16;
    alarm = alarm >> 16;
    return alarm > 0;
}

