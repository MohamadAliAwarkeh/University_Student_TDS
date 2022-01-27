using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadoutManager : MonoBehaviour
{
    [Header("Tank Selection")]
    public TankBodySelection tankBodySelection;
    public SpriteRenderer tankLeftArrow;
    public SpriteRenderer tankRightArrow;
    [Space(10)]
    public SpriteRenderer tankBodyPreview;
    public TextMeshPro tankBodyNameText;
    public TextMeshPro tankSpeedStatText;
    public TextMeshPro tankHealthStatText;

    [Header("Turret Selection")]
    public TankTurretSelection tankTurretSelection;
    public SpriteRenderer turretLeftArrow;
    public SpriteRenderer turretRightArrow;
    [Space(10)]
    public SpriteRenderer tankTurretPreview;
    public TextMeshPro tankTurretNameText;
    public TextMeshPro weaponDamageStatText;
    public TextMeshPro weaponFireRateStatText;
    public TextMeshPro bulletSpreadStatText;
    public TextMeshPro bulletRangeStatText;

    [Header("References")]
    public SpriteRenderer mouseCol;

    //Private variables
    private int currentTankSelection = 0;
    private int currentTurretselection = 0;

    private void Update()
    {
        HandleTankSelection();
        HandleTurretSelection();
    }

    #region Tank Selection
    private void HandleTankSelection()
    {
        //Change selection based on button press
        if (mouseCol.bounds.Intersects(tankLeftArrow.bounds) && Input.GetMouseButtonDown(0))
            currentTankSelection--;

        if (mouseCol.bounds.Intersects(tankRightArrow.bounds) && Input.GetMouseButtonDown(0))
            currentTankSelection++;

        //Loop
        if (currentTankSelection < 0)
            currentTankSelection = 2;
        if (currentTankSelection > 2)
            currentTankSelection = 0;

        //Call function
        DisplayTankSelection();
    }

    public void DisplayTankSelection()
    {
        if (currentTankSelection == 0)
        {
            //Change sprite
            tankBodyPreview.sprite = tankBodySelection.tankBody01;
            //Change tank name
            tankBodyNameText.SetText(tankBodySelection.tankBodyName01);
            //Change tank stat values
            tankSpeedStatText.SetText(tankBodySelection.tankSpeedStat01.ToString());
            tankHealthStatText.SetText(tankBodySelection.tankSpeedStat01.ToString());
        }
        if (currentTankSelection == 1)
        {
            //Change sprite
            tankBodyPreview.sprite = tankBodySelection.tankBody02;
            //Change tank name
            tankBodyNameText.SetText(tankBodySelection.tankBodyName02);
            //Change tank stat values
            tankSpeedStatText.SetText(tankBodySelection.tankSpeedStat02.ToString());
            tankHealthStatText.SetText(tankBodySelection.tankSpeedStat02.ToString());
        }
        if (currentTankSelection == 2)
        {
            //Change sprite
            tankBodyPreview.sprite = tankBodySelection.tankBody03;
            //Change tank name
            tankBodyNameText.SetText(tankBodySelection.tankBodyName03);
            //Change tank stat values
            tankSpeedStatText.SetText(tankBodySelection.tankSpeedStat03.ToString());
            tankHealthStatText.SetText(tankBodySelection.tankSpeedStat03.ToString());
        }
    }
    #endregion

    #region Turret Selection
    private void HandleTurretSelection()
    {
        //Change selection based on button pressed
        if (mouseCol.bounds.Intersects(turretLeftArrow.bounds) && Input.GetMouseButtonDown(0))
            currentTurretselection--;

        if (mouseCol.bounds.Intersects(turretRightArrow.bounds) && Input.GetMouseButtonDown(0))
            currentTurretselection++;

        //Loop
        if (currentTurretselection > 2)
            currentTurretselection = 0;
        if (currentTurretselection < 0)
            currentTurretselection = 2;

        //Call function
        DisplayTurretSelection();
    }

    private void DisplayTurretSelection()
    {
        if (currentTurretselection == 0)
        {
            //Change sprite
            tankTurretPreview.sprite = tankTurretSelection.tankTurret01;
            //Change tank name
            tankTurretNameText.SetText(tankTurretSelection.tankTurretName01);
            //Change tank stat values
            weaponDamageStatText.SetText(tankTurretSelection.weaponDamageStat01.ToString());
            weaponFireRateStatText.SetText(tankTurretSelection.weaponFireRateStat01.ToString());
            bulletSpreadStatText.SetText(tankTurretSelection.bulletSpreadStat01.ToString());
            bulletRangeStatText.SetText(tankTurretSelection.bulletRangeStat01.ToString());  
        }
        if (currentTurretselection == 1)
        {
            //Change sprite
            tankTurretPreview.sprite = tankTurretSelection.tankTurret02;
            //Change tank name
            tankTurretNameText.SetText(tankTurretSelection.tankTurretName02);
            //Change tank stat values
            weaponDamageStatText.SetText(tankTurretSelection.weaponDamageStat02.ToString());
            weaponFireRateStatText.SetText(tankTurretSelection.weaponFireRateStat02.ToString());
            bulletSpreadStatText.SetText(tankTurretSelection.bulletSpreadStat02.ToString());
            bulletRangeStatText.SetText(tankTurretSelection.bulletRangeStat02.ToString());
        }
        if (currentTurretselection == 2)
        {
            //Change sprite
            tankTurretPreview.sprite = tankTurretSelection.tankTurret03;
            //Change tank name
            tankTurretNameText.SetText(tankTurretSelection.tankTurretName03);
            //Change tank stat values
            weaponDamageStatText.SetText(tankTurretSelection.weaponDamageStat03.ToString());
            weaponFireRateStatText.SetText(tankTurretSelection.weaponFireRateStat03.ToString());
            bulletSpreadStatText.SetText(tankTurretSelection.bulletSpreadStat03.ToString());
            bulletRangeStatText.SetText(tankTurretSelection.bulletRangeStat03.ToString());
        }
    }
    #endregion
}
