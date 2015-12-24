/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package wizard;

import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author ivan
 */
public class SimpleCalc {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        String string = "2+22*4-100/2+(3*3)";
        char[] charArray = string.toCharArray();
        List<String> res = new ArrayList<String>();
        System.out.println(charArray.length);
        String buffer = "";
        for (int i = 0; i < charArray.length; i++) {
            if (charArray[i] >= '0' && charArray[i] <= '9') {
                buffer += "" + charArray[i];
            } else {
                if (buffer.length() > 0) {
                    res.add(buffer);
                    buffer = "";
                }
                res.add("" + charArray[i]);
            }
        }
        if (buffer.length() > 0) {
            res.add(buffer);
        }
        viewRes(res);
        System.out.println(proccessBracket(res));
    }

    public static int proccessBracket(List<String> res) {
        while (res.indexOf("(") >= 0) {
            int s = res.indexOf("(");
            int e = res.indexOf(")");
            List<String> res2 = res.subList(s+1, e);
            res.set(s, null);
            res.set(e, null);
            clearArray(res2);
            calc(res2);
            clearArray(res);
        }
        return calc(res);
    }

    public static void multiplay(List<String> res) {
        while (res.indexOf("*") >= 0 || res.indexOf("/") >= 0) {
            int i = 0;
            for (i = 0; i < res.size(); i++) {
                if ((res.get(i).equals("*") || res.get(i).equals("/"))
                        && i > 0 && i < res.size() - 1) {
                    int x = getCalc(res.get(i - 1), res.get(i + 1), res.get(i));
                    res.set(i - 1, null);
                    res.set(i, null);
                    res.set(i + 1, Integer.toString(x));
                }
            }
            clearArray(res);
        }
    }

    public static int calc(List<String> res) {
        multiplay(res);
        int i = 0;
        while (i <= res.size() - 3) {
            int x = getCalc(res.get(i), res.get(i + 2), res.get(i + 1));
            res.set(i, null);
            res.set(i + 1, null);
            res.set(i + 2, Integer.toString(x));
            i += 2;
        }
        clearArray(res);
        return Integer.parseInt(res.get(0));
    }

    public static void clearArray(List<String> res) {
        int i = 0;
        while (i < res.size()) {
            if (res.get(i) == null) {
                res.remove(i);
            } else {
                i++;
            }
        }
    }

    public static int getCalc(String aa, String bb, String operation) {

        int a = Integer.parseInt(aa);
        int b = Integer.parseInt(bb);

        if (operation.equals("+")) {
            return a + b;
        } else if (operation.equals("-")) {
            return a - b;
        } else if (operation.equals("*")) {
            return a * b;
        } else if (operation.equals("/")) {
            return a / b;
        }
        return 0;
    }

    public static void viewRes(List<String> res) {
        System.out.println(res.size());
        for (String item : res) {
            System.out.print(item);
        }
        System.out.println();
    }

}
