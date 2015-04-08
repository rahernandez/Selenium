package com.seleniumsimplified.webdriver.basics.manipulate.windows;

import com.seleniumsimplified.webdriver.manager.Driver;
import org.junit.Test;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;C:\Users\rahernandez2\Documents\My Books\Selenium\Code\Selenium Testing Tools Cookbook_MultipleLanguages\Chapter 2\DotNet\SeleniumApiExamples\SeleniumApiExamples\WindowsExampleTest.java

import java.util.Set;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertTrue;

public class WindowsExampleTest {

	   public void canReturnAWebElementInsteadOfABooleanUsingAnonymousClass(){

        driver = Driver.get("http://compendiumdev.co.uk/selenium/" +
                "basic_ajax.html");

        // select Server
        WebElement categorySelect = driver.findElement(By.id("combo1"));
        categorySelect.findElement(By.cssSelector("option[value='3']")).click();

        // Wait for Java to be available to select
        WebElement elly = new WebDriverWait(driver,10).until(
                new ExpectedCondition<WebElement>() {
                    @Override
                    public WebElement apply(WebDriver webDriver) {

                        WebElement eli = webDriver.findElement(
                                By.cssSelector("option[value='23']"));

                        if(eli.isDisplayed()){
                            return eli;
                        }else{
                            return null;
                        }
                    }
                }
        );


    @Test
    public void switchToNewWindow(){

        // Current bug open with chrome driver
        // http://code.google.com/p/chromedriver/issues/detail?id=107

        WebDriver driver = Driver.get(
                    "http://www.compendiumdev.co.uk/selenium/frames");

        String framesWindowHandle = driver.getWindowHandle();
        assertEquals("Expected only 1 current window", 1, driver.getWindowHandles().size());

        driver.switchTo().frame("content");
        driver.findElement(By.cssSelector("a[href='http://www.seleniumsimplified.com']")).click();
        assertEquals("Expected a New Window opened", 2, driver.getWindowHandles().size());

        Set<String> myWindows = driver.getWindowHandles();
        String newWindowHandle="";

        for(String aHandle : myWindows){
            if(!framesWindowHandle.contentEquals(aHandle)){
                newWindowHandle = aHandle; break;
            }
        }

        driver.switchTo().window(newWindowHandle);

        assertTrue("Expected Selenium Simplified site",
                driver.getTitle().contains("Selenium Simplified"));
    }
}
    @Test
    public void customExpectedConditionForTitleDoesNotContainUsingMethodAC(){

        WebDriverWait wait;

        driver = Driver.get("http://compendiumdev.co.uk/selenium/" +
                "basic_redirect.html");
        wait = new WebDriverWait(driver,8);

        driver.findElement((By.id("delaygotobasic"))).click();

        assertEquals("Basic Web Page Title",
                wait.until(titleDoesNotContainAC("Redirects")));
    }

    private ExpectedCondition<String> titleDoesNotContainAC(final String stringNotInTitle) {
        return new ExpectedCondition<String>() {
            @Override
            public String apply(WebDriver webDriver) {
                String title = webDriver.getTitle();

                if(title.contains(stringNotInTitle)){
                    return null;
                }else{
                    return title;
                }
            }
        };
    }
}